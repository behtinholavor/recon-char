using System;
using Tesseract;
//https://www.youtube.com/watch?v=Qa3sHphE8LI&feature=youtu.be
//https://github.com/tesseract-ocr/

namespace recon_char
{
    static class Program
    {

        static void Main(string[] args)
        {
            //var img = @"C:\_projects\personal\net\recon-char\files-char\number-image.png";
            //var img = @"C:\_projects\personal\net\recon-char\files-char\card-image.png";
            //var img = @"C:\_projects\personal\net\recon-char\files-char\binary-image.png";
            var img = @"C:\_projects\personal\net\recon-char\files-char\order-image.png";

            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
                {
                    using (var image = Pix.LoadFromFile(img))
                    {
                        using (var page = engine.Process(image))
                        {
                            var text = page.GetText();
                            var rate = page.GetMeanConfidence() * 100;

                            Console.WriteLine("Rate: {0}",  rate.ToString() + "%");
                            Console.WriteLine("Text: /r/n{0}", text);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                Console.ReadLine();
            }


        }
    }
}
