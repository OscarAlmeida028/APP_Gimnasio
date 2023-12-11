using Newtonsoft.Json;
using System.Text;
using APP_Gimnasio.Models;
using Newtonsoft.Json;
using System.Text;
using APP_Gimnasio.Service;
using System.Net.Http;

public class APIService
{
    private static string _baseURL;
    public HttpClient httpClient;


    public APIService()
    {
        // Añadir el archivo JSON al contenedor

        _baseURL = "https://programacionivapiproyectop1gimnasio.azurewebsites.net/";
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(_baseURL);
    }

    //MEMBRESIA
    public async Task<List<Membresia>> GetMembresia()
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/api/Membresia");

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            List<Membresia> membresias = JsonConvert.DeserializeObject<List<Membresia>>(content);

            return membresias;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<Membresia> CreateMembresia(Membresia newMembresia)
    {

        var json = JsonConvert.SerializeObject(newMembresia);

        var newMembresiaJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a POST request to the API
        HttpResponseMessage response = await httpClient.PostAsync(_baseURL + "/api/Membresia", newMembresiaJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Membresia objects
            Membresia membresiaNueva = JsonConvert.DeserializeObject<Membresia>(content);

            return membresiaNueva;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<Membresia> GetMembresiaByID(int idMembresia)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/api/Membresia/" + idMembresia);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Membresia membresiaEncontrada = JsonConvert.DeserializeObject<Membresia>(content);

            return membresiaEncontrada;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<Membresia> UpdateMembresia(Membresia newMembresia, int idMembresia)
    {

        var json = JsonConvert.SerializeObject(newMembresia);
        var newMembresiaJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a PUT request to the API
        HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "/api/Membresia/" + idMembresia, newMembresiaJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Membresia membresiaModificada = JsonConvert.DeserializeObject<Membresia>(content);

            return membresiaModificada;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }


    public async Task<string> DeleteMembresia(int idMembresia)
    {
        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "/api/Membresia/" + idMembresia);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string mensaje = await response.Content.ReadAsStringAsync();

            return mensaje;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    // 3 Métodos del final adicionales de la API Membresía

    public async Task<List<Miembro>> GetMiembrosDeUnaMembresia(int idMembresia)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/MiembrosDeUnaMembresia/" + idMembresia);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            List<Miembro> miembrosDeUnaMembresia = JsonConvert.DeserializeObject<List<Miembro>>(content);

            return miembrosDeUnaMembresia;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<string> RenovarMembresia(int idMiembro)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/RenovarMembresia/" + idMiembro);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string mensaje = await response.Content.ReadAsStringAsync();

            return mensaje;

        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<string> CancelarMembresia(int idMiembro)
    {
        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "/EliminarMembresia/" + idMiembro);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string mensaje = await response.Content.ReadAsStringAsync();

            return mensaje;

        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }

    //MIEMBRO
    public async Task<Miembro> CreateMiembro(Miembro newMiembro)
    {

        var json = JsonConvert.SerializeObject(newMiembro);

        var newMiembroJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a POST request to the API
        HttpResponseMessage response = await httpClient.PostAsync(_baseURL + "/api/Miembro", newMiembroJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Miembro miembroNuevo = JsonConvert.DeserializeObject<Miembro>(content);

            return miembroNuevo;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<string> DeleteMiembro(int idMiembro)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "/api/Miembro/" + idMiembro);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string mensaje = await response.Content.ReadAsStringAsync();

            return mensaje;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<List<Miembro>> GetMiembros()
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/api/Miembro");

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            List<Miembro> miembros = JsonConvert.DeserializeObject<List<Miembro>>(content);

            return miembros;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<Miembro> GetMiembroByID(int idMiembro)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/api/Miembro/" + idMiembro);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Miembro miembroEncontrado = JsonConvert.DeserializeObject<Miembro>(content);

            return miembroEncontrado;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }

    public async Task<Miembro> UpdateMiembro(Miembro newMiembro, int idMiembro)
    {

        var json = JsonConvert.SerializeObject(newMiembro);

        var newProductJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a PUT request to the API
        HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "/api/Miembro/" + idMiembro, newProductJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Miembro miembroModificado = JsonConvert.DeserializeObject<Miembro>(content);

            return miembroModificado;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }

    //PAGO
    public async Task<Pago> CreatePago(Pago newPago)
    {

        var json = JsonConvert.SerializeObject(newPago);

        var newPagoJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a POST request to the API
        HttpResponseMessage response = await httpClient.PostAsync(_baseURL + "/api/Pago", newPagoJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Pago pagoNuevo = JsonConvert.DeserializeObject<Pago>(content);

            return pagoNuevo;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }

    public async Task<string> DeletePago(int idPago)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "/api/Pago/" + idPago);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string mensaje = await response.Content.ReadAsStringAsync();

            return mensaje;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<List<Pago>> GetPagos()
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/api/Pago");

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            List<Pago> pagos = JsonConvert.DeserializeObject<List<Pago>>(content);

            return pagos;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<List<Pago>> GetPagosPorMiembro(int idMiembro)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/PagosPorMiembro/" + idMiembro);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            List<Pago> pagosDeUnMiembro = JsonConvert.DeserializeObject<List<Pago>>(content);

            return pagosDeUnMiembro;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<Pago> GetPagoByID(int idPago)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/api/Pago/" + idPago);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Pago pagoEncontrado = JsonConvert.DeserializeObject<Pago>(content);

            return pagoEncontrado;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }

    public async Task<Pago> UpdatePago(Pago newPago, int idPago)
    {

        var json = JsonConvert.SerializeObject(newPago);

        var newPagoJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a PUT request to the API
        HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "/api/Pago/" + idPago, newPagoJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Pago pagoModificado = JsonConvert.DeserializeObject<Pago>(content);

            return pagoModificado;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }

    //VISITA
    public async Task<Visita> CreateVisita(Visita newVisita)
    {

        var json = JsonConvert.SerializeObject(newVisita);

        var newVisitaJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a POST request to the API
        HttpResponseMessage response = await httpClient.PostAsync(_baseURL + "/api/Visita", newVisitaJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Visita visitaNueva = JsonConvert.DeserializeObject<Visita>(content);

            return visitaNueva;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<string> DeleteVisita(int idVisita)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "/api/Visita/" + idVisita);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string mensaje = await response.Content.ReadAsStringAsync();

            return mensaje;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<List<Visita>> GetVisitas()
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/api/Visita");

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            List<Visita> visitas = JsonConvert.DeserializeObject<List<Visita>>(content);

            return visitas;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<List<Visita>> GetVisitasPorMiembro(int idMiembro)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/VisitasPorMiembro/" + idMiembro);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            List<Visita> visitasDeUnMiembro = JsonConvert.DeserializeObject<List<Visita>>(content);

            return visitasDeUnMiembro;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }

    }

    public async Task<Visita> GetVisitaByID(int idVisita)
    {

        // Send a GET request to the API
        HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "/api/Visita/" + idVisita);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Visita visitaEncontrada = JsonConvert.DeserializeObject<Visita>(content);

            return visitaEncontrada;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }

    public async Task<Visita> UpdateVisita(Visita newVisita, int idVisita)
    {

        var json = JsonConvert.SerializeObject(newVisita);

        var newVisitaJSON = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a PUT request to the API
        HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "/api/Visita/" + idVisita, newVisitaJSON);

        // Ensure the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of Producto objects
            Visita visitaModificada = JsonConvert.DeserializeObject<Visita>(content);

            return visitaModificada;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }

    //Login
    public async Task<Miembro> LoginMiembro(Miembro miembro)
    { 
        var response = await httpClient.GetAsync(_baseURL+ "/api/Miembro");

        if (response.IsSuccessStatusCode )
        {
            var jsoResponse = await response.Content.ReadAsStringAsync();
            List<Miembro> miembros = JsonConvert.DeserializeObject<List<Miembro>>(jsoResponse);

            Miembro miembroEncontrado = miembros.Find(m => m.emailMiembro == miembro.emailMiembro && m.passwordMiembro == miembro.passwordMiembro);

            if (miembroEncontrado != null)
            {
                return miembroEncontrado;
            }
        }
        return null;
    }
}

