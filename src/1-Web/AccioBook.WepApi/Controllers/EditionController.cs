namespace AccioBook.WepApi.Controllers
{
    public class EditionController
    {

        /// <summary>
        /// Insere uma nova edição.
        /// </summary>     
        /// <returns></returns>

        //[HttpPost("insertEdition")]
        //public async Task<IActionResult> InsertEdition(EditionModel editionArgs)
        //{
        //    var edition = new Edition();

        //    edition.Id = editionArgs.Id;
        //    edition.Id_Book = editionArgs.Id_Book;
        //    edition.Id_Publisher = editionArgs.Id_Publisher;
        //    edition.Id_Language = editionArgs.Id_Language;
        //    edition.Cover = editionArgs.Cover;
        //    edition.PublicationDate = editionArgs.PublicationDate;
        //    edition.PageCount = editionArgs.PageCount;
        //    edition.ISBNCode_10 = editionArgs.ISBNCode_10;
        //    edition.ISBNCode_13 = editionArgs.ISBNCode_13;

        //    Book book = new Book();
        //    book.Id = editionArgs.Book.Id;
        //    book.Title = editionArgs.Book.Title;
        //    edition.Book = book;

        //    Publisher publisher = new Publisher();
        //    publisher.Id = editionArgs.Publisher.Id;
        //    publisher.Name = editionArgs.Publisher.Name;
        //    edition.Publisher = publisher;

        //    Language language = new Language();
        //    language.Id = editionArgs.Language.Id;
        //    language.Name = editionArgs.Language.Name;
        //    edition.Language = language;


        //    edition = await _editionService.AddAndSaveAsync(edition);

        //    if (edition.Id != default(int))
        //    {
        //        return Ok(edition);
        //    }

        //    return BadRequest();
        //}

        ///// <summary>
        ///// Deleta uma edição do banco
        ///// </summary>
        ///// <returns></returns>
        //[HttpDelete("deleteEdition")]
        //public async Task<IActionResult> DeleteEdition(EditionModel editionArgs)
        //{
        //    var edition = new Edition();

        //    edition.Id = editionArgs.Id;

        //    try
        //    {
        //        await _editionService.DeleteAsync(edition.Id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        ///// <summary>
        ///// Atualiza uma edição existente no banco.
        ///// </summary>     
        ///// <returns></returns>

        //[HttpPut("updateEdition")]
        //public async Task<IActionResult> UpdateEdition(EditionModel editionArgs)
        //{
        //    var edition = await _editionService.GetAsync(editionArgs.Id);

        //    if (edition == null)
        //    {
        //        return NotFound();
        //    }

        //    edition.Id = editionArgs.Id;
        //    edition.Id_Book = editionArgs.Id_Book;
        //    edition.Id_Publisher = editionArgs.Id_Publisher;
        //    edition.Id_Language = editionArgs.Id_Language;
        //    edition.Cover = editionArgs.Cover;
        //    edition.PublicationDate = editionArgs.PublicationDate;
        //    edition.PageCount = editionArgs.PageCount;
        //    edition.ISBNCode_10 = editionArgs.ISBNCode_10;
        //    edition.ISBNCode_13 = editionArgs.ISBNCode_13;

        //    Book book = new Book();
        //    book.Id = editionArgs.Book.Id;
        //    book.Title = editionArgs.Book.Title;
        //    edition.Book = book;

        //    Publisher publisher = new Publisher();
        //    publisher.Id = editionArgs.Publisher.Id;
        //    publisher.Name = editionArgs.Publisher.Name;
        //    edition.Publisher = publisher;

        //    Language language = new Language();
        //    language.Id = editionArgs.Language.Id;
        //    language.Name = editionArgs.Language.Name;
        //    edition.Language = language;

        //    try
        //    {
        //        await _editionService.UpdateAndSaveAsync(edition);
        //        return Ok(edition);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
