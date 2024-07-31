import { Grid } from "@mui/material";
import UserAvatar from "./UserAvatar.jsx";
import UserInfoFullName from "./UserInfoFullName/UserInfoFullName.jsx";

const UserInfoProfileDetails = () => {
  return (
    <Grid
      container
      justifyContent="start"
      alignItems="center"
      flexWrap="nowrap"
      sx={{ marginBottom: "13px", paddingLeft: "23px" }}
    >
      <UserAvatar />
      <UserInfoFullName />
    </Grid>
  );
};
export default UserInfoProfileDetails;
