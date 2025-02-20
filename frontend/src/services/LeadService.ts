import { Lead } from '../interfaces/Lead';
import api from './Api';

const LEADS_URL = 'api/Leads';

export const getLeadsByStatus = async (status: string): Promise<Lead[]> => {
    const response = await api.get<Lead[]>(`${LEADS_URL}/${status}`);
    return response.data;
};

export const acceptLead = async (id: number): Promise<void> => {
    await api.put(`${LEADS_URL}/Accept/${id}`);
};

export const declineLead = async (id: number): Promise<void> => {
    await api.put(`${LEADS_URL}/Decline/${id}`);
};