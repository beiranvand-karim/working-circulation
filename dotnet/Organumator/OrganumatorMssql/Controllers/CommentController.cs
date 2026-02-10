using Microsoft.AspNetCore.Mvc;
using OrganumatorMssql.Dtos.Comment;
using OrganumatorMssql.Interfaces;
using OrganumatorMssql.Mappers;
using OrganumatorMssql.Models;

namespace OrganumatorMssql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IStockRepository _stockRepository;
        public CommentController(ICommentsRepository commentsRepository
        , IStockRepository stockRepository)
        {
            this._commentsRepository = commentsRepository;
            this._stockRepository = stockRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentsRepository.GetAllAsync();
            return Ok(comments.Select(c => c.ToCommentDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentsRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();


            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            var createdComment = await _commentsRepository.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = createdComment.Id }, createdComment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Comment comment)
        {
            var updatedComment = await _commentsRepository.UpdateAsync(id, comment);
            if (updatedComment == null)
            {
                return NotFound();
            }
            return Ok(updatedComment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedComment = await _commentsRepository.DeleteAsync(id);
            if (deletedComment == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("create/{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
        {
            if (!await _stockRepository.StockExists(stockId))
            {
                return BadRequest($"Stock with id {stockId} not found.");
            }

            var commentModel = commentDto.ToCommentFromCreateDto(stockId);

            var createdComment = await _commentsRepository.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = createdComment.Id }, createdComment.ToCommentDto());
        }

    }
}