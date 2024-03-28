export type Member = {
    memberId: number;
    firstName: string;
    lastName: string;
    idNumber: number;
    address: string;
    city: string;
    street: string;
    streetNumber: string;
    birthDate: Date;
    phone: string;
    mobilePhone: string;
    positiveTestDate: Date;
    recoveryDate: Date;
    image: string;
    vaccines:Vaccine[];
  }
  export type Vaccine = {
    memberId: number;
    vaccinationDate: string;
    manufacturer: string;
  }