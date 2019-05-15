using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace NHibernateExemplo.Models
{
	public class AlunoService
	{
		private readonly ISession session;

		public AlunoService()
		{
			session = NHibernateHelper.OpenSession();
		}

		public IList<Aluno> GetAll()
		{
			return session.Query<Aluno>().ToList();
		}

		public void AddOrUpdate(Aluno aluno)
		{
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.Save(aluno);
				transaction.Commit();
			}
		}

		public void Remove(Aluno aluno)
		{
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.Delete(aluno);
				transaction.Commit();
			}
		}

		public void Remove(int id)
		{
			var aluno = session.Get<Aluno>(id);
			if (aluno == null)
				throw new ObjectNotFoundException(id, "Aluno");
			Remove(aluno);
		}
	}
}