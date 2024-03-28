import React, { useState, ChangeEvent } from "react";
import { addVaccineByMemberId } from "../utils/vaccinesUtil";
import { Vaccine } from "./type";
import { ActionType } from "./actionTypeEnum";

interface VaccinesListProps {
  actionType: ActionType;
  memberId: number;
  vaccines: Vaccine[];
}

export default function VaccinesList({
  actionType,
  memberId,
  vaccines,
}: VaccinesListProps) {
  const [isAddVaccine, setIsAddVaccine] = useState<boolean>(false);
  const [newVaccine, setNewVaccine] = useState<Vaccine>({
    memberId: memberId,
    vaccinationDate: "",
    manufacturer: "",
  });

  const addVaccine = async (vaccine: Vaccine) => {
    try {
      await addVaccineByMemberId(vaccine);
      alert("Vaccine successfully added.");
      setIsAddVaccine(false);
    } catch (error) {
      alert("Error: Vaccine could not be added.");
      console.error("Error adding vaccine:", error);
    }
  };

  const addVaccineForm = (
    <div className="dialog" style={{ zIndex: " 20" }}>
      <div className="div" style={{ flexDirection: "column" }}>
        <dt>vaccinationDate</dt>
        <input
          type="date"
          onChange={(e) => handleChange(e, "vaccinationDate")}
        />
        <dt>manufacturer</dt>
        <input type="text" onChange={(e) => handleChange(e, "manufacturer")} />
      </div>
      <div className="div">
        <button
          style={{ backgroundColor: "rgb(71, 92, 200)" }}
          onClick={() => addVaccine(newVaccine)}
        >
          add
        </button>
        <button
          style={{ backgroundColor: "red" }}
          onClick={() => setIsAddVaccine(false)}
        >
          cancel
        </button>
      </div>
    </div>
  );

  const handleChange = (
    e: ChangeEvent<HTMLInputElement | HTMLSelectElement>,
    fieldName: string
  ) => {
    const { value } = e.target;
    setNewVaccine((prevVaccine) => ({
      ...prevVaccine,
      [fieldName]: value,
    }));
  };

  return (
    <div>
      <div className="div" style={{ alignItems: "baseline" }}>
        <h4>vaccines</h4>
        {actionType !== ActionType.Show && (
          <button
            style={{ backgroundColor: "rgb(71, 92, 200)" }}
            disabled={vaccines.length > 3}
            onClick={() => setIsAddVaccine(true)}
          >
            Add vaccine
          </button>
        )}
      </div>
      {vaccines.map((vaccine, index) => (
        <div
          key={index}
          className="div"
          style={{ display: "flex", gap: "10px" }}
        >
          <span>{index + 1}</span>
          <span>{vaccine.vaccinationDate}</span>
          <span>{vaccine.manufacturer}</span>
        </div>
      ))}
      {!vaccines || vaccines.length === 0 ? (
        <span>no vaccines data for member</span>
      ) : null}
      {isAddVaccine && addVaccineForm}
    </div>
  );
}
