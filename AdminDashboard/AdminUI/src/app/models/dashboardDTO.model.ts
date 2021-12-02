import { AppointmentDTO } from "./appointmentDTO.model";

export class DashboardDTO {
  dentists: number;
  clients: number;
  appointments: number;
  earnings: number;
  recentAppointments: AppointmentDTO[];
}
