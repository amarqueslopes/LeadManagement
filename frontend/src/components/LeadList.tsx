import React, { useEffect, useState } from 'react';
import { getLeadsByStatus, acceptLead, declineLead } from '../services/LeadService';
import { Lead } from '../interfaces/Lead';
import LeadCard from './LeadCard';

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
        const leads: Lead[] = [
            {
                id: 1,
                firstName: "Chris",
                lastName: "Brown",
                dateCreated: "2024-02-19T10:30:00Z",
                suburb: "Downtown",
                category: "Plumbing",
                description: "Fixing a leaking pipe in the kitchen.",
                price: 600,
                status: "Invited",
                email: "john.doe@example.com",
                phoneNumber: "+1 555-432-1234"
            },
            {
                id: 2,
                firstName: "Pete",
                lastName: "Smith",
                dateCreated: "2024-02-08T14:45:00Z",
                suburb: "Uptown",
                category: "Electrical",
                description: "Rewiring the living room.",
                price: 450,
                status: "Accepted",
                email: "jane.smith@example.com",
                phoneNumber: "+1 555-765-5678"
            },
            {
                id: 3,
                firstName: "Alice",
                lastName: "Johnson",
                dateCreated: "2024-02-17T09:15:00Z",
                suburb: "Suburbia",
                category: "Carpentry",
                description: "Building custom shelves.",
                price: 750,
                status: "Invited",
                email: "alice.johnson@example.com",
                phoneNumber: "+1 555-789-9876"
            },
            {
                id: 4,
                firstName: "Craig",
                lastName: "Sanderson Jr.",
                dateCreated: "2024-01-29T18:15:00Z",
                suburb: "Uptown",
                category: "Electrical",
                description: "Rewiring the living room.",
                price: 450,
                status: "Accepted",
                email: "jane.smith@example.com",
                phoneNumber: "+1 555-765-5678"
            },
        ];
        setLeads(leads.filter(l => l.status === status));

        //fetchLeads();
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
        <div>
            {leads.map((lead, index) => (
                <LeadCard
                    index={index}
                    lead={lead}
                    onAccept={handleAccept}
                    onDecline={handleDecline}
                />
            ))}
        </div>
    );
};

export default LeadList;