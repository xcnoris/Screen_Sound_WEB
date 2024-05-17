﻿

using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using System.Net.Http;
using System.Net.Http.Json;

namespace ScreenSound.WEB.Services
{
    public class ArtistasAPI
    {
        private readonly HttpClient _httpClient;
        public ArtistasAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        // Metodo consulta a class ArtistaResponse, consulta nossa api por meio do response
        public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
        }

   
        public async Task AddArtistaAsync(ArtistaRequest artista)
        {
            await _httpClient.PostAsJsonAsync("artistas", artista);
        }

        public async Task UpdateArtistaAsync(ArtistaRequestEdit artista)
        {
            await _httpClient.PutAsJsonAsync($"artistas", artista);
        }



        public async Task DeleteArtistaAsync(int id)
        {
            await _httpClient.DeleteAsync($"artistas/{id}");
        }


        public async Task<ArtistaResponse?> GetArtistaPorNomeAsync(string nome)
        {
            return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artistas/{nome}");
        }
    }


}

