import React, { useCallback, useEffect, useState } from "react";
import {
  addMember,
  deleteMember,
  getAllMembers,
  getMemberById,
  updateMember,
} from "../utils/memberUtil";
import { Member } from "./type";
import { ActionType } from "./actionTypeEnum";
import OneMember from "./OneMember";
import {
  XYPlot,
  VerticalBarSeries,
  XAxis,
  YAxis,
  VerticalGridLines,
  HorizontalGridLines,
  
} from "react-vis";
import { MemberActionDialog } from "./MemberActionDialog";

interface HomeProps {}

export default function Home(props: HomeProps) {
  const [members, setMembers] = useState<Member[]>([]);
  const [openDialog, setOpenDialog] = useState<boolean>(false);
  const [dialogContent, setDialogContent] = useState<JSX.Element | null>(null);
  const [nonVaccinatedMembers, setNonVaccinatedMembers] = useState<number>(0);
  const [membersSickByDay, setMembersSickByDay] = useState<
    { x: string; y: number }[]
  >([]);

  const fetchAllMembers =async () => {
    try {
      const res: Member[] = await getAllMembers();
      setMembers(res);

      const currentDate = new Date();
      const last30Days = new Array(30).fill(null).map((_, index) => {
        const date = new Date(
          currentDate.getTime() - index * 24 * 60 * 60 * 1000
        );
        return date.toLocaleDateString(); // Assuming you want date in a string format
      });

      const membersSickByDay = last30Days.map((day) => {
        const dayStart = new Date(day);
        const dayEnd = new Date(dayStart.getTime() + 24 * 60 * 60 * 1000);
        const count = res.filter((member) => {
          const positiveTestDate = new Date(member.positiveTestDate);
          return positiveTestDate >= dayStart && positiveTestDate < dayEnd;
        }).length;
        return { day: dayStart, count: count };
      });
      const transformedData = membersSickByDay.map((item) => ({
        x: item.day.toLocaleDateString("en-US", {
          month: "short",
          day: "numeric",
        }),
        y: item.count,
      }));

      // Set the state variable
      setMembersSickByDay(transformedData);
      setNonVaccinatedMembers(
        res.filter((member) => !member.vaccines.length).length
      );
    } catch (error) {
      console.error(
        "Error fetching all members data:",
        (error as Error).message
      );
    }
  };

  useEffect(() => {
    fetchAllMembers();
  }, []);

  const newMemberState: Member = {
    memberId: 0,
    firstName: "",
    lastName: "",
    idNumber: 0,
    address: "",
    city: "",
    street: "",
    streetNumber: "",
    birthDate: new Date(),
    phone: "",
    mobilePhone: "",
    positiveTestDate: new Date(),
    recoveryDate: new Date(),
    image: "",
    vaccines: [],
  };

  const handleClick = async (
    actionType: ActionType,
    action: (member: Member) => void,
    member: Member
  ) => {
    setOpenDialog(true);
    setDialogContent(
      <div className="dialog" style={{ zIndex: 10 }}>
        <div>
          <MemberActionDialog
            actionType={actionType}
            action={action}
            member={member}
            closeDialog={closeDialog}
          />
        </div>
      </div>
    );
  };

  const handleAddMember = async (member: Member) => {
    try {
      await addMember(member);
      fetchAllMembers();
    } catch (error) {
      console.error("Error add member:", (error as Error).message);
    }
  };

  const handleShowMember = async (member: Member) => {
    try {
      await getMemberById(member.memberId);
    } catch (error) {
      console.error("Error fetching member data:", (error as Error).message);
    }
  };

  const handleRemoveMember = async (id: number) => {
    try {
      const confirmRemove = window.confirm(
        "Are you sure you want to remove this member?"
      );
      if (confirmRemove) {
        await deleteMember(id);
        fetchAllMembers();
      }
    } catch (error) {
      console.error("Error remove member:", (error as Error).message);
    }
  };

  const handleUpdateMember = async (member: Member) => {
    try {
      await updateMember(member.memberId, member);
      fetchAllMembers();
      alert("member data successfully updated");
    } catch (error) {
      console.error("Error update member data:", (error as Error).message);
    }
  };

  const closeDialog = () => {
    setDialogContent(null);
    setOpenDialog(false);
  };

  return (
    <>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          gap: 10,
        }}
      >
        <h1>Members Data List</h1>
        <div className="div">
          <h6>Total Members: {members.length}</h6>
          <h6>
            {nonVaccinatedMembers !== undefined
              ? `Non-vaccinated members: ${nonVaccinatedMembers}`
              : ""}
          </h6>
        </div>
        <XYPlot
        // style={{display:"flex"}}
          height={200}
          width={600}
          xType="ordinal"

          // margin={{ left: 50, bottom: 50 }}
        >
          <VerticalGridLines />
          <HorizontalGridLines />
          <XAxis tickLabelAngle={-90} style={{ fontSize: "10px" }} />
          <YAxis
            tickTotal={20}
            tickFormat={(v: number) => Math.floor(v).toString()}
            tickValues={[1,2,3 ,4, 5]}
          />
          <VerticalBarSeries  data={membersSickByDay} barWidth={0.5}/>
        </XYPlot>
        <button
          style={{ backgroundColor: "rgb(71, 92, 200)" }}
          onClick={() =>
            handleClick(ActionType.Add, handleAddMember, newMemberState)
          }
        >
          Add Member
        </button>
        {members.map((member, index) => (
          <OneMember
            key={index}
            member={member}
            handleShowMember={handleShowMember}
            handleUpdateMember={handleUpdateMember}
            handleRemoveMember={handleRemoveMember}
            handleClick={handleClick}
          />
        ))}
      </div>
      {openDialog && dialogContent}
    </>
  );
}
