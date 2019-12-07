export interface ITheme {
  color: {
    primary: string;
    darkPrimary: string;

    black: string;
    
    white: string;
    lightGrey: string;
    gray: string;
    grey: string;

    red: string;

    orange: string;
    darkOrange: string;
  };
}

const theme: ITheme = {
  color: {
    primary: '#0095ff',
    darkPrimary: '#07C',

    black: '#1B1F3B',
    
    white: '#ffffff',
    gray: 'rgba(0, 0, 0, 0.25)',
    lightGrey: '#ededed',
    grey: '#6a737c',

    red: '#E62652',

    orange: '#F2871F',
    darkOrange: '#ba610b'
  }
};

export default theme;
