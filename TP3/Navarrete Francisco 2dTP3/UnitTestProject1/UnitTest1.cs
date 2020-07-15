using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_instanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        // prueba 
        public void TestInstanciarAlumno()
        {
            Alumno alumno = new Alumno(1, "Francisco", "Navarrete", "22222333", 0, 0);
            Assert.IsNotNull(alumno);
        }


        [TestMethod]
        public void TestValidarNombre()
        {
            Alumno alumno = new Alumno();
            string apellido = "Arias123";
            alumno.Apellido = apellido;
            Assert.IsTrue(alumno.Apellido==String.Empty);
        }
        

        [TestMethod]
        public void TestAtributosTipoColeccionEnUniversidad()
        {
            Universidad universidad = new Universidad(); 
            Alumno alumno = new Alumno(1, "Francisco", "Navarrete", "22222333", 0, 0);
            universidad+=alumno;
            Assert.IsNotNull(universidad.Alumnos);
        }


        [TestMethod]
        public void TestAtributosTipoColeccionEnJornada()
        {
            Profesor p = new Profesor(1, "p", "c", "12345678", Persona.ENacionalidad.Argentino);
            Jornada j = new Jornada(Universidad.EClases.Laboratorio, p);
            Alumno alumno = new Alumno(1, "Francisco", "Navarrete", "22222333", 0, 0);
            j += alumno;

            Assert.IsNotNull(j.Alumnos);
        }


        [ExpectedException (typeof(AlumnoRepetidoException))]
        [TestMethod]
        public void TestAlumnoRepetidoException()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Francisco", "Navarrete", "22222333", 0, 0);
            Alumno alumno2 = new Alumno(1, "Francisco", "Navarrete", "22222333", 0, 0);
            universidad += alumno;
            universidad += alumno2; 
        }


        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesorException()
        {
            Profesor instructor = new Profesor(1, "Francisco", "Navarrete", "22222333", 0);
            Alumno alumno = new Alumno(1, "Francisco", "Navarrete", "22222333", 0, 0);
            Universidad universidad = new Universidad();
            universidad += instructor;
            universidad += alumno;
            universidad += Universidad.EClases.Laboratorio;
            universidad += Universidad.EClases.Programacion;
            universidad += Universidad.EClases.SPD;
            universidad += Universidad.EClases.Legislacion;
        }


        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosException()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Universidad.xml";
            xml.Guardar(archivo, universidad);
        }
    }
}
