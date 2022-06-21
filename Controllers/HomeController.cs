using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservations.Models;
using Reservations.Repositories;

namespace Reservations.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepository;
        

        public HomeController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            
        }
        
        public ActionResult Index()
        {
            return View(_eventRepository.GetAllActive());
        }
        //YourListOfEvent
        public ActionResult Participation()
        {
            return View(_eventRepository.GetAllActiveBilets());
            
        }

        // CreateEvent
        
        public ActionResult CreateEvent()
        {
            return View(new ReservationModel()); 
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent( ReservationModel eModel)
        {
            
            _eventRepository.Add(eModel);
            
            return RedirectToAction(nameof(Index));
         
        }
        //DetailsEvent
        public ActionResult DetailsEvent(int id)
        {
            return View(_eventRepository.Get(id));
        }
        
        //BiletDetails
        public ActionResult BiletDetails(int id)
        {
            return View(_eventRepository.GetBilet(id));
        }
        
        // CreateBilet
        public ActionResult CreateBilet(int id)
        {
            ReservationModel res = _eventRepository.Get(id);
            BiletModel bModel = new BiletModel();
            bModel.Description = res.DescriptionEvent;
            bModel.EventId = res.EventId;
            bModel.NameBilet = res.Name;
            bModel.DescriptionBilet = "Bez numeracji miejsc";
            return View(bModel); 
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBilet(int id, BiletModel bModel)
        {
            ReservationModel res = _eventRepository.Get(id);
            
            bModel.Description = res.DescriptionEvent;
            bModel.EventId = res.EventId;
            bModel.NameBilet = res.Name;
            bModel.DescriptionBilet = "Bez numeracji miejsc";
            
            res.AvailableSeats = res.AvailableSeats - bModel.NumberOfSeats;
            if(res.AvailableSeats < 0)
            {
                res.AvailableSeats = res.AvailableSeats + bModel.NumberOfSeats;
                _eventRepository.Update(id, res);
                return RedirectToAction(nameof(WarningReservation));
            }
            _eventRepository.AddBilet(bModel);
            _eventRepository.Update(id, res);
            return RedirectToAction(nameof(Index));
         
        }

        public ActionResult WarningReservation()
        {
            return View();
        }

        // EditEvent
        public ActionResult EditEvent(int id)
        {
            return View(_eventRepository.Get(id));
        }
    
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(int id, ReservationModel resModel)
        {
            _eventRepository.Update(id, resModel);
            
            return RedirectToAction(nameof(Index));
        }
        
        //EditBilet
        public ActionResult EditBilet(int id)
        {
            return View(_eventRepository.GetBilet(id));
        }
    
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBilet(int id, BiletModel bModel)
        {
            _eventRepository.UpdateBilet(id, bModel);
            
            return RedirectToAction(nameof(Participation));
        }
    
        // DeleteEvent
        public ActionResult DeleteEvent(int id)
        {
            return View(_eventRepository.Get(id));
        }
    
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(int id, ReservationModel resModel)
        {
            _eventRepository.Delete(id);
            BiletModel b;
            
            return RedirectToAction(nameof(Index));
        }
        
        // DeleteBilet
        public ActionResult DeleteBilet(int id)
        {
            return View(_eventRepository.GetBilet(id));
        }
    
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBilet(int id, BiletModel bModel)
        {
            BiletModel b = _eventRepository.GetBilet(id);
            ReservationModel res = _eventRepository.Get(b.EventId);
            int value = b.NumberOfSeats;
            _eventRepository.DeleteBilet(id);
            res.AvailableSeats = value + res.AvailableSeats;
            _eventRepository.Update(res.EventId, res);
            return RedirectToAction(nameof(Index));
        }
    }
}