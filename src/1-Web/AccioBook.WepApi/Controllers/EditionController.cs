using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.Domain.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AccioBook.WepApi.Controllers
{
    /// <summary>
    /// AccioBook documentação  
    /// </summary>
    [Route("edition")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class EditionController : ControllerBase
    {
        private readonly IEditionService _editionService;
        public EditionController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        /// <summary>
        /// Insere uma edição no banco.
        /// </summary>     
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(EditionModel editionArgs)
        {
            var edition = new Edition();
                        
            edition.Id_Book = editionArgs.Id_Book;
            edition.Id_Publisher = editionArgs.Id_Publisher;
            edition.Id_Language = editionArgs.Id_Language;
            edition.Cover = editionArgs.Cover;
            edition.PublicationDate = editionArgs.PublicationDate;
            edition.PageCount = editionArgs.PageCount;
            edition.ISBNCode_10 = editionArgs.ISBNCode_10;
            edition.ISBNCode_13 = editionArgs.ISBNCode_13;                     


            edition = await _editionService.AddAndSaveAsync(edition);

            if (edition.Id != default(int))
            {
                return Ok(edition);
            }

            return BadRequest();
        }

        /// <summary>
        /// Deleta uma edição do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{editionId}")]
        public async Task<IActionResult> DeleteEdition(Int64 editionId)
        {
            try
            {
                await _editionService.DeleteAsync(editionId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma edição existente no banco.
        /// </summary>     
        /// <returns></returns>

        [HttpPut("update/{editionId}")]
        public async Task<IActionResult> Update(Int64 editionId, EditionModel editionArgs)
        {
            var edition = await _editionService.GetAsync(editionId);

            if (edition == null)
            {
                return NotFound();
            }
            
            edition.Id_Book = editionArgs.Id_Book;
            edition.Id_Publisher = editionArgs.Id_Publisher;
            edition.Id_Language = editionArgs.Id_Language;
            edition.Cover = editionArgs.Cover;
            edition.PublicationDate = editionArgs.PublicationDate;
            edition.PageCount = editionArgs.PageCount;
            edition.ISBNCode_10 = editionArgs.ISBNCode_10;
            edition.ISBNCode_13 = editionArgs.ISBNCode_13;

            await _editionService.UpdateAndSaveAsync(edition);

            return Ok(edition);
        }

        /// <summary>
        /// Retorna as últimas 100 edições
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-last-100")]
        public async Task<IActionResult> GetEditionsLast100()
        {
            try
            {
                var edition = await _editionService.GetLastEditionsTop100();
                return Ok(edition);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna toda lista de edições
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetEdition()
        {
            try
            {
                var edition = await _editionService.GetAllAsync();
                return Ok(edition);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }     

    }
}
