import React from "react";
import { Member } from "./type";
import { ActionType } from "./actionTypeEnum";

interface OneMemberProps {
    member: Member;
    handleRemoveMember: (id: number) => void; 
    handleUpdateMember: (member: Member) => Promise<void>;
    handleShowMember: (member: Member) => Promise<void>; 
    handleClick:(actionType: ActionType, action: (member: Member) => void, member: Member) => Promise<void>;
  }

const OneMember: React.FC<OneMemberProps> = ({
  member,
  handleRemoveMember,
  handleUpdateMember,
  handleShowMember,
  handleClick,
}) => {
  return (
    <div
      style={{
        display: "flex",
        width: "90%",
        border: "2px solid grey",
        gap: 10,
        padding: "5px 20px",
        justifyContent: "space-between",
      }}
    >
      <div style={{ display: "flex", gap: 10 }}>
        <span style={{ fontWeight: 700 }}>
          {member.firstName} {member.lastName}
        </span>
        <span>id: {member.idNumber}</span>
      </div>
      <div style={{ display: "flex", gap: 5 }}>
        <button
          className="show-button"
          onClick={() => handleClick(ActionType.Show, handleShowMember, member)}
        >
          show
        </button>
        <button
          className="update-button"
          onClick={() => handleClick(ActionType.Update, handleUpdateMember, member)}
        >
          update
        </button>
        <button
          className="remove-button"
          onClick={() => handleRemoveMember(member.memberId)}
        >
          remove
        </button>
      </div>
    </div>
  );
};

export default OneMember;
