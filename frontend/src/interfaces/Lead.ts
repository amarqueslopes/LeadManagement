export interface Lead {
    id: number;
    firstName: string;
    lastName: string;
    dateCreated: string;
    suburb: string;
    category: string;
    description: string;
    price: number;
    status: string;
    email?: string;
    phoneNumber?: string;
}