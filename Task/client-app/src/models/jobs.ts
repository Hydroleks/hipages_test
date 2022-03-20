export interface Job {
    id: string;
    status: string;
    suburb: string;
    category: string;
    contactName: string;
    contactPhone: string;
    contactEmail: string;
    price: number;
    description: string;
    created: Date;
    updated: Date;
}