import React, { useState, ChangeEvent } from "react";
import VaccinesList from "./VaccinesList";
import { Member } from "./type";
import { ActionType } from "./actionTypeEnum";
import defaultImg from "../default-user-image.png"

interface MemberActionProps {
  actionType: ActionType;
  action: (member: Member) => void;
  member: Member;
  closeDialog: () => void;
}

export const MemberActionDialog: React.FC<MemberActionProps> = ({
  actionType,
  action,
  member,
  closeDialog,
}) => {
  const [memberState, setMember] = useState<Member>(member);

  const handleChange = (
    e: ChangeEvent<HTMLInputElement | HTMLSelectElement>,
    fieldName: string
  ) => {
    const { value } = e.target;
    setMember((prevMember) => ({
      ...prevMember,
      [fieldName]: value,
    }));
  };
  const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files && event.target.files.length > 0) {
      const selectedImage = event.target.files[0];
      const reader = new FileReader();
      reader.onload = _handleReaderLoaded;
      reader.readAsBinaryString(selectedImage);
    }
  };

  const _handleReaderLoaded = (event: ProgressEvent<FileReader>) => {
    const binaryString = event.target?.result as string;
    if (binaryString) {
      const base64String = btoa(binaryString);
      setMember((prevMember) => ({
        ...prevMember,
        image: base64String,
      }));
    }
  };

  const handleSubmit = () => {
    const requiredFields = [
      "firstName",
      "lastName",
      "idNumber",
      "birthDate",
      "address",
      "phone",
    ];
    const missingFields = requiredFields.filter(
      (field) => !memberState[field as keyof Member]
    );
    if (missingFields.length > 0) {
      alert("Please fill in all required fields.");
      return;
    }

    if (String(memberState.idNumber).length !== 9) {
      alert("The ID number must be exactly 9 digits.");
      return;
    }

    const { birthDate, positiveTestDate, recoveryDate } = memberState;
    if (
      new Date(birthDate) >= new Date(positiveTestDate) ||
      new Date(positiveTestDate) >= new Date(recoveryDate)
    ) {
      alert("Dates must be in correct order.");
      return;
    }

    action(memberState);
    closeDialog();
  };

  return (
    <div style={{ padding: "0px 30px" }}>
      <div className="div">
        <h2>
          {memberState.firstName} {memberState.lastName}
        </h2>
        <img
          style={{ height: "30px", width: "30px" }}
          src={
            memberState.image
              ? `data:image/jpeg;base64,${memberState.image}`
              : defaultImg
          }
          alt="Member"
        ></img>
      </div>
      <dl style={{ display: "flex", flexDirection: "column", gap: "5px" }}>
        {Object.keys(memberState).map((fieldName, index) => (
          <div key={index} className="div">
            {fieldName !== "memberId" &&
              fieldName !== "vaccines" &&
              fieldName !== "image" && (
                <>
                  <dt>{fieldName}</dt>
                  {fieldName.toLowerCase().includes("date") ? (
                    <input
                      type="datetime-local"
                      disabled={
                        actionType === ActionType.Show ||
                        fieldName === "firstName" ||
                        fieldName === "lastName"
                      }
                      value={String(memberState[fieldName as keyof Member])}
                      onChange={(e) => handleChange(e, fieldName)}
                    />
                  ) : (
                    <input
                      type="text"
                      disabled={actionType === ActionType.Show}
                      value={String(memberState[fieldName as keyof Member])}
                      onChange={(e) => handleChange(e, fieldName)}
                    />
                  )}
                </>
              )}
          </div>
        ))}
        {actionType !== ActionType.Show && (
          <div className="div">
            <dt>image</dt>
            <input
              type="file"
              onChange={(e) => handleImageChange(e)}
            />
          </div>
        )}
        <VaccinesList
          actionType={actionType}
          memberId={member.memberId}
          vaccines={memberState.vaccines}
        />
      </dl>

      {actionType !== ActionType.Show && (
        <button
          style={{
            backgroundColor: "rgb(71, 92, 200)",
          }}
          onClick={handleSubmit}
        >
          {actionType === ActionType.Update ? "Update" : "Add"}
        </button>
      )}
      <button style={{ backgroundColor: "red" }} onClick={closeDialog}>
        Cancel
      </button>
    </div>
  );
};
