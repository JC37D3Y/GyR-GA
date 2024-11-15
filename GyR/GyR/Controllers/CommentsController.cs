using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using GyR.Models;
 // Asegúrate de usar el espacio de nombres correcto donde está tu ApplicationDbContext

namespace GyR.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor para inicializar el contexto
        public CommentsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        // Acción para obtener todos los comentarios (se usa en AJAX para cargar los comentarios en la vista)
        [HttpGet]
        public async Task<ActionResult> GetComments()
        {
            var comments = await _context.Comments
                .OrderByDescending(c => c.DateCreated)
                .ToListAsync();

            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        // Acción para añadir un nuevo comentario a la base de datos
        [HttpPost]
        public async Task<ActionResult> AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.DateCreated = DateTime.Now;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return Json(comment); // Retorna el comentario recién guardado
            }
            return new HttpStatusCodeResult(400, "Datos de comentario inválidos");
        }

        // Liberar los recursos del contexto cuando el controlador se destruya
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
