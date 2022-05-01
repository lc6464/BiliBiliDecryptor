// See https://aka.ms/new-console-template for more information
const string L40 = "----------------------------------------";


if (args.Length == 0) {
	Console.WriteLine("No file!");
}

foreach (var one in args) {
	Console.WriteLine(L40);
	FileInfo info = new(one);
	Console.WriteLine(info.FullName);
	if (info.Exists) {
		FileInfo newInfo = new(Path.Combine(info.DirectoryName ?? "", $"{ Path.GetFileNameWithoutExtension(info.Name) } - Decrypted{ info.Extension }"));
		if (!newInfo.Exists) {
			try {
				FileStream file = info.OpenRead();
				if (file.Length > 3) {
					// 255, 255, 255
					bool fileFirst3FF = true;
					fileFirst3FF &= file.ReadByte() == 255;
					fileFirst3FF &= file.ReadByte() == 255;
					if (fileFirst3FF && file.ReadByte() == 255) {
						try {
							FileStream newFile = newInfo.Create();
							try {
								Console.WriteLine("Decrypting...");
								file.CopyTo(newFile);
								file.Dispose();
								newFile.Flush();
								newFile.Dispose();
								Console.WriteLine("Decrypted successfully!");
														} catch (Exception e) {
								Console.Error.WriteLine($"Decryption error!");
								Console.Error.WriteLine(e);
							}
						} catch (Exception e) {
							Console.Error.WriteLine($"File \"{ newInfo.Name }\" creation error!");
							Console.Error.WriteLine(e);
						}
					} else {
						Console.Error.WriteLine($"File \"{ info.Name }\" does not a valid encrypted file!\r\nThe first 3 bytes are not FF.");
					}
				} else {
					Console.Error.WriteLine($"File \"{ info.Name }\" does not a valid encrypted file!\r\nFile size is less than 3 bytes.");
				}
			} catch (Exception e) {
				Console.Error.WriteLine($"Open encrypted file \"{ info.Name }\" error!");
				Console.Error.WriteLine(e);
			}
		} else {
			Console.Error.WriteLine($"File \"{ newInfo.Name }\" already exists!");
		}
		
	} else {
		Console.Error.WriteLine($"File \"{ info.Name }\" does not exist!");
	}
}

Console.WriteLine(L40);
Console.WriteLine("\r\nPress any key to exit.");
Console.ReadKey();