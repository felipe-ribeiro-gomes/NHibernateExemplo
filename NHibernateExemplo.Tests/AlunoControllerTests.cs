using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernateExemplo.Models;
using System.Linq;

namespace NHibernateExemplo.Tests
{
	[TestClass]
	public class AlunoControllerTests
	{
		[TestMethod]
		public void TestMethod1()
		{
			//instanciar serviço
			var service = new AlunoService();

			//obter todos os registros
			var alunos = service.GetAll();
			Assert.AreEqual(4, alunos.Count());

			//adicionar aluno
			var aluno = new Aluno
			{
				Nome = "Hendrick Splitzer Fenerhaber Jr.",
				Curso = "Medicina",
				Email = "me@fenerhaberenterprises.com",
				Sexo = "M",
			};
			service.AddOrUpdate(aluno);
			alunos = service.GetAll();
			Assert.AreEqual(5, alunos.Count());
			Assert.AreEqual("Hendrick Splitzer Fenerhaber Jr.", alunos.Last().Nome);

			//editar aluno
			aluno.Curso = "Direito";
			service.AddOrUpdate(aluno);
			alunos = service.GetAll();
			Assert.AreEqual(5, alunos.Count());
			Assert.AreEqual("Direito", alunos.Last().Curso);

			//remover aluno
			service.Remove(aluno);
			alunos = service.GetAll();
			Assert.AreEqual(4, alunos.Count());
		}
	}
}
