module.exports = {
  extends: [
    'stylelint-config-standard',
    'stylelint-config-sass-guidelines',
    "stylelint-config-standard-scss",
    "stylelint-config-clean-order",
  ],
  "plugins": [
    "stylelint-order"
  ],
  "rules": {
    "color-named": null,
    "selector-max-id": 1,
    "declaration-property-value-disallowed-list": null,
    "selector-class-pattern": null,
  }
};
