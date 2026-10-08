using Eventos.Data.Db;
using Microsoft.AspNetCore.Mvc;
using Eventos.Web.Models;
using Eventos.Data.Repositorios;
using Eventos.Data.Entidades;

public class EventoVMController : Controller
{
    private readonly IEventoRepository _eventoRepository;

    public EventoVMController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }



    public ActionResult Index()
    {
        List<EventoVM> eventos = new List<EventoVM>();
        var eventosDb = _eventoRepository.ObtenerEventos();


        eventos = eventosDb.Select(e => new EventoVM
        {
            Id = e.Id,
            NombreEvento = e.NombreEvento,
            FechaEvento = e.FechaEvento,

        }).ToList();


        return View(eventos);
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(EventoVM evento)
    {

        Evento nuevoEvento = new Evento
        {
            NombreEvento = evento.NombreEvento,
            FechaEvento = evento.FechaEvento,
        };

        _eventoRepository.AgregarEvento(nuevoEvento);

        return RedirectToAction("Index");

    }

    public ActionResult Details(int id)
    {

        Evento? eventoDb = _eventoRepository.ObtenerEventoPorId(id);

        if(eventoDb == null)
        {
            return NotFound();
        }

        EventoVM evento = new EventoVM
        {
            Id = eventoDb.Id,
            NombreEvento = eventoDb.NombreEvento,
            FechaEvento = eventoDb.FechaEvento
        };

        return View(evento);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {

        Evento? eventoDb = _eventoRepository.ObtenerEventoPorId(id);

       
        if (eventoDb == null)
        {
            return NotFound();
        }

        EventoVM evento = new EventoVM
        {
            Id = eventoDb.Id,
            NombreEvento = eventoDb.NombreEvento,
            FechaEvento = eventoDb.FechaEvento
        };


        return View(evento);
    }

    [HttpPost]
    public ActionResult Edit(EventoVM evento)
    {
        Evento? eventoDb = _eventoRepository.ObtenerEventoPorId(evento.Id);


        if (eventoDb == null)
        {
            return NotFound();
        }

        eventoDb.NombreEvento = evento.NombreEvento;
        eventoDb.FechaEvento = evento.FechaEvento;

        _eventoRepository.ActualizarEvento(eventoDb);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {

        Evento? eventoDb = _eventoRepository.ObtenerEventoPorId(id);

        if (eventoDb == null)
        {
            return NotFound();
        }

        EventoVM evento = new EventoVM
        {
            NombreEvento = eventoDb.NombreEvento,
            FechaEvento = eventoDb.FechaEvento,
        };

        return View(evento);
    }

    [HttpPost]
    public ActionResult Delete(EventoVM evento)
    {

        _eventoRepository.BorrarEvento(evento.Id);
        return RedirectToAction("Index");
    }

}
