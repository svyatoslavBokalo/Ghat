import { Grid, Typography } from "@mui/material";
import typography from "../../../theme/typography.js";
import palette from "../../../theme/palette.js";
import "./UserInfoFullName.scss";

const UserInfoFullName = () => {
  const userData = {
    firstName: "Martha",
    lastName: "Craig",
  };

  return (
    <Grid
      display="flex"
      flexDirection="column"
      alignItems="flex-start"
      width="100%"
      marginLeft="14px"
    >
      <Typography sx={{ flex: 1, ...typography.body1, padding: "8px 10px" }}>
        {userData.firstName}
      </Typography>
      <div
        className="user-info__separator"
        style={{ backgroundColor: palette.grey["100"] }}
      />
      <Typography sx={{ flex: 1, ...typography.body1, padding: "8px 10px" }}>
        {userData.lastName}
      </Typography>
    </Grid>
  );
};

export default UserInfoFullName;
