using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Data.Db;
using Eventos.Data.Entidades;

namespace Eventos.Data.Repositorios
{
    
    public interface IEventoRepository
    {
        void ActualizarEvento(Evento evento);
        bool AgregarEvento(Evento evento);
        bool BorrarEvento(int id);
        Evento? ObtenerEventoPorId(int id);
        List<Evento> ObtenerEventos();
    }
    
    public class EventoRepository : IEventoRepository
    {
        private readonly EventosContext _db;

        public EventoRepository (EventosContext context)
        {
            _db = context;
        }

        public bool AgregarEvento(Evento evento)
        {
            try
            {
                _db.Eventos.Add(evento);
                _db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public List<Evento> ObtenerEventos()
        {
            return _db.Eventos.ToList();
        }

        public Evento? ObtenerEventoPorId(int id)
        {
            return _db.Eventos.Find(id);
        }

        public void ActualizarEvento(Evento evento)
        {
            _db.Eventos.Update(evento);
            _db.SaveChanges();
        }

        public bool BorrarEvento(int id)
        {
            try
            {
                Evento? evento = _db.Eventos.Find(id);
                if (evento != null)
                {
                    _db.Eventos.Remove(evento);
                    _db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
