import { Vaccine } from "../components/type";
import api from "./api";



const getVaccinesByMemberId = async (memberId: number): Promise<Vaccine[]> => {
  try {
    const response = await api.get<Vaccine[]>(`vaccines/${memberId}`);
    return response.data;
  } catch (error) {
    console.error("Error while fetching vaccines by memberID:", error);
    throw error;
  }
};

const addVaccineByMemberId = async (vaccineData: Vaccine): Promise<Vaccine> => {
  try {
    const response = await api.post<Vaccine>("vaccines", vaccineData);
    return response.data;
  } catch (error) {
    console.error("Error while adding vaccine data:", error);
    throw error;
  }
};

export { getVaccinesByMemberId, addVaccineByMemberId };
