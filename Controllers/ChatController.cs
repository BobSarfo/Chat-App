using ChatApp.Dtos;
using ChatApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDictionary<string, ConnectedUserDto> _connections;

        public ChatController(IUnitOfWork unitOfWork, IDictionary<string, ConnectedUserDto> connections)
        {
            _unitOfWork = unitOfWork;
            _connections = connections;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RoomChat()
        {

            return View();
        }

        public async Task<IActionResult> PrivateChat()
        {

            return View();
        }
    }
}
