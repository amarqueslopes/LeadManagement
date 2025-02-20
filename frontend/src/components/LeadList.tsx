import React, { useEffect, useState } from 'react';
import { getLeadsByStatus, acceptLead, declineLead } from '../services/LeadService';
import { Lead } from '../interfaces/Lead';
import LeadCard from './LeadCard';
import { Box } from '@mui/material';

interface LeadListProps {
    status: string;
}

const LeadList: React.FC<LeadListProps> = ({ status }) => {
    const [leads, setLeads] = useState<Lead[]>([]);

    useEffect(() => {
        const fetchLeads = async () => {
            try {
                const data = await getLeadsByStatus(status);
                console.log(data);
                setLeads(data);
            } catch (error) {
                console.error('Error fetching leads:', error);
            }
        };

        fetchLeads();
    }, [status]);

    const handleAccept = async (id: number) => {
        try {
            await acceptLead(id);
            setLeads(leads.filter(lead => lead.id !== id));
        } catch (error) {
            console.error('Error accepting lead:', error);
        }
    };

    const handleDecline = async (id: number) => {
        try {
            await declineLead(id);
            setLeads(leads.filter(lead => lead.id !== id));
        } catch (error) {
            console.error('Error declining lead:', error);
        }
    };

    return (
        <Box>
            {leads.map((lead, index) => (
                <LeadCard
                    index={index}
                    lead={lead}
                    onAccept={handleAccept}
                    onDecline={handleDecline}
                />
            ))}
        </Box>
    );
};

export default LeadList;