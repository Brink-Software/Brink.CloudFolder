using Windows.Storage;

namespace CloudFolder
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var path = args.Length > 0 ? args[0] : string.Empty;
            if(string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                Console.WriteLine("Provide a valid path pointing to a file on OneDrive folder\nFor Example: C:\\Users\\pbons\\OneDrive - Brink\test.txt");
                Console.ReadKey();
                return;
            }

            var file = await StorageFile.GetFileFromPathAsync(path);

            var props = await file?.Properties.RetrievePropertiesAsync(new[]
            {
                "System.FolderNameDisplay",
                "System.StorageProviderFileRemoteUri",
                "System.StorageProviderId"
            });
            foreach (var prop in props)
                Console.WriteLine($"{prop.Key}: {prop.Value}");
            Console.WriteLine($"DotNet version: {Environment.Version}");
            Console.WriteLine($"OS version: {Environment.OSVersion}");

            Console.ReadKey();
        }
    }
}

/*
 * using Windows.Storage;
using Windows.Storage.Provider;

namespace CloudFolder
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var path = args.Length > 0 ? args[0] : string.Empty;
            if(string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                Console.WriteLine("Geef een geldig pad naar je One Drive folder\nBijvoorbeeld: C:\\Users\\pbons\\OneDrive - Brink");
                Console.ReadKey();
                return;
            }

            var folder = await StorageFolder.GetFolderFromPathAsync(path);
            var info = StorageProviderSyncRootManager.GetSyncRootInformationForFolder(folder);

            folder = info.Path as StorageFolder;

            var props = await folder?.Properties.RetrievePropertiesAsync(new[]
            {
                "System.FolderNameDisplay",
                "System.StorageProviderFileRemoteUri",
                "System.StorageProviderId"
            });
            foreach (var prop in props)
                Console.WriteLine($"{prop.Key}: {prop.Value}");
            Console.WriteLine($"DotNet version: {Environment.Version}");
            Console.WriteLine($"OS version: {Environment.OSVersion}");

            Console.ReadKey();
        }
    }
}
 */