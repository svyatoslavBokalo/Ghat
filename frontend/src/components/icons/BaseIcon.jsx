const BaseIcon = ({ name, params }) => {
  const CustomIcon = name;

  const paramsDefault = {
    width: "24px",
    height: "24px",
    color: "white",
    padding: "3px",
    borderRadius: "5px",
  };

  return <CustomIcon style={{ ...paramsDefault, ...params }} />;
};
export default BaseIcon;
