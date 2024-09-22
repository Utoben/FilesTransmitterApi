using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace xsd_transmitter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileDownload : Controller
    {
        [HttpGet("download")]
        public IActionResult DownloadFile()
        {
            // Путь к файлу (можно задать полный путь или относительный к корню проекта)
            var filePath = "files/goods-catalog-schema.xsd";

            // Проверяем, существует ли файл
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            // Читаем файл в байты
            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            // Возвращаем файл с соответствующим контент-тайпом и заголовком для загрузки
            return File(fileBytes, "application/octet-stream", Path.GetFileName(filePath));
        }
    }
}
