﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AppConsig.Comum;
using AppConsig.Dados;
using AppConsig.Servicos.Interfaces;

namespace AppConsig.Servicos
{
    public class ServicoEntidade<T> : IServicoEntidade<T> where T : EntidadeBase
    {
        protected IContexto Contexto;
        protected IDbSet<T> Dbset;

        /// <summary>
        /// Serviço base para entidades.
        /// </summary>
        /// <param name="contexto"></param>
        public ServicoEntidade(IContexto contexto)
        {
            Contexto = contexto;
            Dbset = contexto.Set<T>();
        }

        /// <summary>
        /// Retorna a entidade buscando pelo seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T ObterPeloId(long id)
        {
            return Dbset.Find(id);
        }

        /// <summary>
        /// Retorna todas as entidades.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> ObterTodos(Expression<Func<T, bool>> filtro = null)
        {
            return filtro != null ? Dbset.Where(filtro).AsEnumerable() : Dbset.AsEnumerable();
        }

        /// <summary>
        /// Retorna todas as entidades.
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="tamanhaPagina"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> ObterTodosPaginado(Expression<Func<T, bool>> filtro = null, int numeroPagina = 1, int tamanhaPagina = 5)
        {
            return filtro != null
                ? Dbset.Where(filtro).Skip(tamanhaPagina * (numeroPagina - 1)).Take(tamanhaPagina).AsEnumerable()
                : Dbset.Skip(tamanhaPagina * (numeroPagina - 1)).Take(tamanhaPagina).AsEnumerable();
        }

        /// <summary>
        /// Cria uma nova entidade.
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Criar(T entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException("entidade");
            }

            Dbset.Add(entidade);
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma entidade.
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Atualizar(T entidade)
        {
            if (entidade == null) throw new ArgumentNullException("entidade");

            Contexto.Entry(entidade).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Exclui uma entidade.
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Excluir(T entidade)
        {
            if (entidade == null) throw new ArgumentNullException("entidade");

            // Entidades auditaveis não podem ser excluidas da fonte de dados.
            // Será setado como verdadeiro na coluna "Excluido" e então atualizado.
            if (entidade is EntidadeAuditavel<T>)
            {
                var t = entidade.GetType();
                var propInfo = t.GetProperty("Excluido");

                propInfo.SetValue(entidade, true, null);

                Contexto.Entry(entidade).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
            else
            {
                // Entidade é excluida permanentemente da fonte de dado.
                Dbset.Remove(entidade);
                Contexto.SaveChanges();
            }
        }
    }
}