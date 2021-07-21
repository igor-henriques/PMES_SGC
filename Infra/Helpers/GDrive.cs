using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Helpers
{
    public class GDrive
    {
        public bool succesfullUploaded = false;
        public long bytesUploaded = 0;

        public async Task<UserCredential> GetUserCredentialAsync()
        {
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string[] scopes = { DriveService.Scope.Drive };

                string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                creadPath = Path.Combine(creadPath, "driveApiCredentials", "drive-credentials.json");

                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    (await GoogleClientSecrets.FromStreamAsync(stream)).Secrets,
                    scopes,
                    "User",
                    CancellationToken.None,
                    new FileDataStore(creadPath, true));
            }
        }

        public  DriveService GetDriveService(UserCredential credential)
        {
            return new DriveService(
                    new BaseClientService.Initializer
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "PCCLient"
                    }
                );
        }
        public async Task<string> Upload(DriveService service, string filePath, string fileName, string parentFolderId, string contentType)
        {
            try
            {
                var fileMetadata = new Google.Apis.Drive.v3.Data.File();

                fileMetadata.Name = fileName;
                fileMetadata.Parents = new List<string> { parentFolderId };

                FilesResource.CreateMediaUpload request;

                using (var stream = new FileStream(ZipDatabase(filePath, fileName), FileMode.Open))
                {
                    request = service.Files.Create(fileMetadata, stream, contentType);

                    request.ProgressChanged += Request_ProgressChanged;
                    request.ResponseReceived += Request_ResponseReceived;

                    await request.UploadAsync();
                }

                var file = request.ResponseBody;

                return file.Id;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }
        private string ZipDatabase(string filePath, string fileName)
        {
            File.Delete($"{filePath}.zip");

            using (var zip = ZipFile.Open(filePath + ".zip", ZipArchiveMode.Create))
                zip.CreateEntryFromFile(filePath, "sam_database.sqlite");

            return $"{filePath}.zip";
        }

        private void Request_ProgressChanged(Google.Apis.Upload.IUploadProgress obj)
        {
            bytesUploaded = obj.BytesSent;
        }

        private void Request_ResponseReceived(Google.Apis.Drive.v3.Data.File obj)
        {
            if (obj != null)
            {
                succesfullUploaded = true;
            }
        }
    }
}
