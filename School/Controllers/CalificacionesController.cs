using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.DataAccess;
using School.Models;
using School.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace School.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly ICalificacionesService _calificacionesService;
        private readonly IEstudianteService _estudianteService;
        private readonly IMateriaService _materiaService;

        public CalificacionesController(ICalificacionesService calificacionesService, IMateriaService materiaService, IEstudianteService estudianteService)
        {
            _calificacionesService = calificacionesService;
            _materiaService = materiaService;
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            GetDropDownItems();

            var calificacionesView = new CalificacionesView()
            {
                MateriaInfo = new Materia(),
                EstudianteInfo = new Estudiante()
            };
            return View(calificacionesView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CalificacionesView calificacionesView)
        {
            if (ModelState.IsValid)
            {
                _calificacionesService.SaveData(calificacionesView);
                TempData["mensaje"] = "La nota se ha guardado exitosamente.";
                return RedirectToAction("Index");
            }
            GetDropDownItems();
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? idEstudiante, int? idMateria, int? academicYear, int? academicSemestre)
        {
            if (idEstudiante == null || idEstudiante == 0
                || idMateria == null || idMateria == 0
                || academicYear == null || academicYear == 0
                || academicSemestre == null || academicSemestre == 0)
            {
                return NotFound();
            }

            var calificacionesView = _calificacionesService
            .GetById(FillCalificacionRequest(idEstudiante, idMateria, academicYear, academicSemestre));

            if (calificacionesView == null)
            {
                NotFound();
            }

            return View(calificacionesView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CalificacionesView calificacionesView)
        {
            var calificacion = _calificacionesService.GetById(calificacionesView);
            if (calificacion == null)
            {
                return NotFound();
            }

            _calificacionesService.Delete(calificacionesView);
            TempData["mensaje"] = "La nota se ha eliminado exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? idEstudiante, int? idMateria, int? academicYear, int? academicSemestre)
        {
            if (idEstudiante == null || idEstudiante == 0
                || idMateria == null || idMateria == 0
                || academicYear == null || academicYear == 0
                || academicSemestre == null || academicSemestre == 0)
            {
                return NotFound();
            }

            var calificacionesView = _calificacionesService
            .GetById(FillCalificacionRequest(idEstudiante, idMateria, academicYear, academicSemestre));

            if (calificacionesView == null)
            {
                NotFound();
            }

            return View(calificacionesView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CalificacionesView calificacionesView)
        {
            if (ModelState.IsValid)
            {
                _calificacionesService.SaveData(calificacionesView);
                TempData["mensaje"] = "La nota se ha actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            GetDropDownItems();
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<CalificacionesView> listCalificaciones = _calificacionesService.GetAll();
            return View(listCalificaciones);
        }

        private static CalificacionesView FillCalificacionRequest(int? idEstudiante, int? idMateria, int? academicYear, int? academicSemestre)
        {
            return new CalificacionesView()
            {
                EstudianteInfo = new Estudiante()
                {
                    IdEstudiante = (int)idEstudiante
                },
                MateriaInfo = new Materia()
                {
                    IdMateria = (int)idMateria
                },
                AcademicSemestre = (int)academicSemestre,
                AcademicYear = (int)academicYear
            };
        }

        private void GetDropDownItems()
        {
            var materias = _materiaService.GetAll();
            var estudiantes = _estudianteService.GetAll();
            ViewBag.Materias = new SelectList(materias, "IdMateria", "Descripcion");
            ViewBag.Estudiantes = new SelectList(estudiantes, "IdEstudiante", "Nombre");
        }
    }
}