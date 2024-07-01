import React from 'react';
import Navbar from './components/Navbar';
import PessoaList from './components/PessoaList';
import PessoaForm from './components/PessoaForm';
import './App.css';

const App = () => {
  return (
    <div>
      <Navbar />
      <PessoaForm />
      <PessoaList />
    </div>
  );
};

export default App;
