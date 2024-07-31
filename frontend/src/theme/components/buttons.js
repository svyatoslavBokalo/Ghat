import palette from "../palette";

const buttons = {
  MuiButton: {
    styleOverrides: {
      root: {
        height: "52px",
        textTransform: "none",
        fontSize: "16px",
        lineHeight: "16px",
        letterSpacing: "1px",
      },
      outlined: {
        borderColor: palette.primary.main,
      },
      sizeSmall: {
        height: "48px",
        minWidth: "160px",
      },
    },
  },
  MuiIconButton: {
    styleOverrides: {
      sizeLarge: {
        padding: 0,
      },
    },
  },
};

export default buttons;
