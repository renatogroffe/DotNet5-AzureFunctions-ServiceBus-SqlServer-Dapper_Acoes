using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using FunctionAppProcessarAcoes.Models;

namespace FunctionAppProcessarAcoes.Data
{
    public class AcoesRepository
    {
        public AcoesRepository()
        {
        }

        public void Save(DadosAcao dadosAcao)
        {
            using var conexao = new SqlConnection(
                Environment.GetEnvironmentVariable("BaseAcoes_Connection"));
            conexao.Insert<Acao>(new ()
            {
                Codigo = dadosAcao.Codigo,
                DataReferencia = DateTime.Now,
                Valor = dadosAcao.Valor
            });
        }

        public IEnumerable<Acao> GetAll()
        {
            using var conexao = new SqlConnection(
                Environment.GetEnvironmentVariable("BaseAcoes_Connection"));
            return conexao.GetAll<Acao>();
        }
    }
}