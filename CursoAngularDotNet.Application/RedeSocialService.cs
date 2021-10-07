using AutoMapper;
using CursoAngularDotNet.Application.Contratos;
using CursoAngularDotNet.Application.Dtos;
using CursoAngularDotNet.Domain;
using CursoAngularDotNet.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAngularDotNet.Application
{
    public class RedeSocialService : IRedeSocialService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IRedeSocialPersist _redeSocialPersist;
        private readonly IMapper _mapper;

        public RedeSocialService(IGeralPersist geralPersist,
                             IRedeSocialPersist redeSocialPersist,
                             IMapper mapper)
        {
             _geralPersist = geralPersist;
             _redeSocialPersist = redeSocialPersist;
             _mapper = mapper;
        }

        public async Task AddRedeSocial(int eventoId, RedeSocialDto model)
        {
            try
            {
                var redeSocial = _mapper.Map<RedeSocial>(model);
                redeSocial.EventoId = eventoId;

                _geralPersist.Add<RedeSocial>(redeSocial);

                await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RedeSocialDto[]> SaveRedesSociais(int eventoId, RedeSocialDto[] models)
        {
            try
            {
                var redesSociais = await _redeSocialPersist.GetRedesSociaisByEventoIdAsync(eventoId);
                if (redesSociais == null) return null;

                foreach (var model in models)
                {
                    if (model.Id == 0)
                    {
                        await AddRedeSocial(eventoId, model);
                    }
                    else
                    {
                        var redeSocial = redesSociais.FirstOrDefault(redeSocial => redeSocial.Id == model.Id);
                        model.EventoId = eventoId;

                        _mapper.Map(model, redeSocial);

                        _geralPersist.Update<RedeSocial>(redeSocial);

                        await _geralPersist.SaveChangesAsync();
                    }
                }

                var redeSocialRetorno = await _redeSocialPersist.GetRedesSociaisByEventoIdAsync(eventoId);

                return _mapper.Map<RedeSocialDto[]>(redeSocialRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteRedeSocial(int eventoId, int redeSocialId)
        {
            try
            {
                var redeSocial = await _redeSocialPersist.GetRedeSocialByIdsAsync(eventoId, redeSocialId);
                if (redeSocial == null) throw new Exception("Rede Social para delete não encontrada.");

                _geralPersist.Delete<RedeSocial>(redeSocial);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RedeSocialDto[]> GetRedesSociaisByEventoIdAsync(int eventoId)
        {
            try
            {
                var redesSociais = await _redeSocialPersist.GetRedesSociaisByEventoIdAsync(eventoId);
                if (redesSociais == null) return null;

                var resultado = _mapper.Map<RedeSocialDto[]>(redesSociais);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RedeSocialDto> GetRedeSocialByIdsAsync(int eventoId, int redeSocialId)
        {
            try
            {
                var redeSocial = await _redeSocialPersist.GetRedeSocialByIdsAsync(eventoId, redeSocialId);
                if (redeSocial == null) return null;

                var resultado = _mapper.Map<RedeSocialDto>(redeSocial);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
