using System.Collections.Generic;

namespace Final_youtube.Model
{
    public interface InterIncident
    {
        List<Incident> GetIncidents();
        Incident GetIncidentById(int incidentId);
        void AddIncident(Incident incident);
        void DeleteIncident(int id);
        void UpdateIncident(Incident incident);
    }
}
