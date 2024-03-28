import { Member } from "../components/type";
import api from "./api";



const getAllMembers = async (): Promise<Member[]> => {
  try {
    const response = await api.get<Member[]>(`Members`);
    return response.data;
  } catch (error) {
    console.error("Error while fetching all members:", error);
    throw error;
  }
};

const getMemberById = async (memberId: number): Promise<Member> => {
  try {
    const response = await api.get<Member>(`Members/${memberId}`);
    return response.data;
  } catch (error) {
    console.error("Error while fetching member by ID:", error);
    throw error;
  }
};

const addMember = async (Member: Member): Promise<Member> => {
  try {
    const response = await api.post<Member>("members", Member);
    return response.data;
  } catch (error) {
    console.error("Error while adding member:", error);
    throw error;
  }
};

const updateMember = async (memberId: number, Member: Member): Promise<Member> => {
  try {
    console.log(Member);
    
    const response = await api.put<Member>(`members/${memberId}`,JSON.stringify(Member),{headers:{'Content-Type':"application/json"}});
    return response.data;
  } catch (error) {
    console.error("Error while updating member:", error);
    throw error;
  }
};

const deleteMember = async (memberId: number): Promise<void> => {
  try {
    await api.delete(`members/${memberId}`);
  } catch (error) {
    console.error("Error while deleting member:", error);
    throw error;
  }
};

export { getAllMembers, getMemberById, addMember, updateMember, deleteMember };
