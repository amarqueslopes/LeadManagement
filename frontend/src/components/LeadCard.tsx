import React from 'react';
import { Avatar, Box, Button, Card, CardContent, Typography } from '@mui/material';
import { LocationOn, Work, Phone, Email } from "@mui/icons-material";
import { Lead } from '../interfaces/Lead';


const LeadCard = ({ lead, onAccept, onDecline, index }: { lead: Lead; onAccept: (id: number) => void; onDecline: (id: number) => void; index: number }) => {
    const avatarBgColor = index % 2 === 0 ? "gray" : "orange";

    const formatDate = (dateStr: string) => {
        const date = new Date(dateStr);
        return date.toLocaleString("en-US", { month: "long", day: "numeric", year: "numeric", hour: "2-digit", minute: "2-digit" });
    };

    const formatPrice = (price: number) => {
        return new Intl.NumberFormat("en-US", { style: "currency", currency: "USD" }).format(price);
    };

    return (
        <Card sx={{ marginTop: 2 }}>
            <CardContent>
                <Box display="flex" alignItems="center">
                    <Avatar sx={{ bgcolor: avatarBgColor, color: "white", mr: 2 }}>{lead.firstName[0].toUpperCase()}</Avatar>
                    <Box>
                        <Typography variant="h6" fontWeight="bold">{lead.firstName + (lead.status === "Accepted" ? ` ${lead.lastName}` : "")}</Typography>
                        <Typography variant="body2" fontStyle="italic">{formatDate(lead.dateCreated)}</Typography>
                    </Box>
                </Box>
                <Box display="flex" alignItems="center" mt={2}>
                    <LocationOn sx={{ mr: 1 }} />
                    <Typography variant="body2" sx={{ mr: 2 }}>{lead.suburb}</Typography>
                    <Work sx={{ mr: 1 }} />
                    <Typography variant="body2" sx={{ mr: 2 }}>{lead.category}</Typography>
                    <Typography variant="body2">Job ID:</Typography>
                    <Typography variant="body2" sx={{ marginLeft: 1, mr: 2 }}>{lead.id}</Typography>
                    {lead.status === "Accepted" && (
                        <Typography variant="body2">{formatPrice(lead.price)}</Typography>
                    )}
                </Box>
                {lead.status === "Accepted" && (
                    <Box display="flex" alignItems="center" mt={2}>
                        <Phone sx={{ mr: 1 }} />
                        <Typography variant="body2" fontWeight="bold" color="orange" sx={{ mr: 2 }}>{lead.phoneNumber}</Typography>
                        <Email sx={{ mr: 1 }} />
                        <Typography variant="body2" fontWeight="bold" color="orange">{lead.email}</Typography>
                    </Box>
                )}
                <Box mt={2}>
                    <Typography variant="body2">{lead.description}</Typography>
                </Box>
                {lead.status === "Invited" && (
                    <Box mt={2} display="flex" justifyContent="left">
                        <Button sx={{ mr: 2 }} onClick={() => onAccept(lead.id)} variant="contained" color="primary">
                            Accept
                        </Button>
                        <Button sx={{ mr: 2 }} onClick={() => onDecline(lead.id)} variant="contained" color="secondary">
                            Decline
                        </Button>
                        <Typography sx={{ mt: 1, mr: 1 }} fontWeight="bold" variant="body2">{formatPrice(lead.price)}</Typography>
                        <Typography sx={{ mt: 1 }} variant="body2">Lead Invitation.</Typography>
                    </Box>
                )}
            </CardContent>
        </Card>
    );
};

export default LeadCard;