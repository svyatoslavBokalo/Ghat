module.exports = {
  root: true,
  env: { browser: true, es2020: true },
  extends: [
    'airbnb',
    "airbnb/base",
    'airbnb/hooks',
    'eslint:recommended',
    'plugin:react/recommended',
    'plugin:react/jsx-runtime',
    'plugin:react-hooks/recommended',
    "prettier",
  ],
  ignorePatterns: ['dist', '.eslintrc.cjs', 'node_modules', "*.scss", "*.css"],
  parserOptions: { ecmaVersion: 'latest', sourceType: 'module' },
  settings: { react: { version: '18.2' } },
  plugins: ['react-refresh', "prettier"],
  rules: {
    'react-refresh/only-export-components': [
      'warn',
      { allowConstantExport: true },
    ],
    "prettier/prettier": "error",
    "max-len": ["error", 80, {
      "ignoreStrings": true,
      "ignoreTemplateLiterals": true,
      "ignoreRegExpLiterals": true,
      "ignoreComments": true,
    }],
    'import/no-unresolved': 'off',
    'import/extensions': 'off',
    "react/prop-types": "off",
    "react/function-component-definition": [
      "error",
      {
        "namedComponents": ["function-declaration", "arrow-function"]
      }
    ],
    "arrow-body-style": "off",
    "no-alert": "off",
  },
}
