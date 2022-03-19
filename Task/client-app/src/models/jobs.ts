export interface Job {
    id: string;
    status: string;
    suburbId: string;
    categoryId: string;
    contactName: string;
    contactPhone: string;
    contactEmail: string;
    price: number;
    description: string;
    created: Date;
    updated: Date;
}