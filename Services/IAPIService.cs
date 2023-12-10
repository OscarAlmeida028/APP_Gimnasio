using APP_Gimnasio.Models;

namespace APP_Gimnasio.Service;

public interface IAPIService
{
    //Membresía
    public Task<List<Membresia>> GetMembresia();
    public Task<Membresia> CreateMembresia(Membresia newMembresia);
    public Task<Membresia> GetMembresiaByID(int idMembresia);
    public Task<Membresia> UpdateMembresia(Membresia newMembresia, int idMembresia);
    public Task<string> DeleteMembresia(int idMembresia);
    public Task<List<Miembro>> GetMiembrosDeUnaMembresia(int idMembresia);
    public Task<string> RenovarMembresia(int idMiembro);
    public Task<string> CancelarMembresia(int idMiembro);

    //Miembro
    Task<Miembro> CreateMiembro(Miembro newMiembro);
    Task<string> DeleteMiembro(int idMiembro);
    Task<List<Miembro>> GetMiembros();
    Task<Miembro> GetMiembroByID(int idMiembro);
    Task<Miembro> UpdateMiembro(Miembro newMiembro, int idMiembro);

    //Pago
    public Task<Pago> CreatePago(Pago newPago);
    public Task<string> DeletePago(int idPago);
    public Task<List<Pago>> GetPagos();
    public Task<List<Pago>> GetPagosPorMiembro(int idMiembro);
    public Task<Pago> GetPagoByID(int idPago);
    public Task<Pago> UpdatePago(Pago newPago, int idPago);

    //Visita
    Task<Visita> CreateVisita(Visita newVisita);
    Task<string> DeleteVisita(int idVisita);
    Task<List<Visita>> GetVisitas();
    Task<List<Visita>> GetVisitasPorMiembro(int idMiembro);
    Task<Visita> GetVisitaByID(int idVisita);
    Task<Visita> UpdateVisita(Visita newVisita, int idVisita);

    //Usuario	

}
