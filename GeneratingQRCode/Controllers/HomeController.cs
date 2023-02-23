using GeneratingQRCode.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using static QRCoder.PayloadGenerator;

namespace GeneratingQRCode.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult CreateQRCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQRCode(QRCodeModel qRCode)
        {
            //QRCodeGenerator QrGenerator = new QRCodeGenerator();
            //QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qRCode.QRCodeText, QRCodeGenerator.ECCLevel.Q);
            //QRCode QrCode = new QRCode(QrCodeInfo);
            //Bitmap QrBitmap = QrCode.GetGraphic(60);  
            //byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            //string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            //ViewBag.QrCodeUri = QrUri;


            //OneTimePassword generator = new OneTimePassword()
            //{
            //    Secret = "pwq6 5q55",
            //    Issuer = "Google",
            //    Label = "test@google.com",
            //};
            //string payload = generator.ToString();

            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            //QRCode qrCode = new QRCode(qrCodeData);
            //var QrBitmap = qrCode.GetGraphic(20);
            //byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            //string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            //ViewBag.QrCodeUri = QrUri;

            Url generator = new Url(qRCode.QRCodeText);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var QrBitmap = qrCode.GetGraphic(20);
            byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            ViewBag.QrCodeUri = QrUri;

            return View();
        }
    }

    //Extension method to convert Bitmap to Byte Array
    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
