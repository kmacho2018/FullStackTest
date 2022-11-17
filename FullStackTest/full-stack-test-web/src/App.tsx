import React from 'react';
import logo from './logo.svg';
import './App.css';
import Skeleton, { SkeletonTheme } from 'react-loading-skeleton'
import 'react-loading-skeleton/dist/skeleton.css'
import styled from '@emotion/styled'

const Button = styled.button`
  padding: 32px;
  background-color: hotpink;
  font-size: 24px;
  border-radius: 4px;
  color: black;
  font-weight: bold;
  &:hover {
    color: white;
  }
`

function App() {
  return (
    <div className="App">
      <header className="App-header">
      <Button>This my button component.</Button>
      <SkeletonTheme baseColor="#202020" highlightColor="#444">
        <p>
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
            <Skeleton count={3} />
        </p>
    </SkeletonTheme>
        
       
      </header>
    </div>
  );
}

export default App;
