import React from 'react';

const Navbar = () => {
  return (
    <nav className="navbar">
      <h1>Gerenciamento de Pessoas</h1>
      <ul>
        <li><a href="#adicionar-pessoa">Adicionar Pessoa</a></li>
        <li><a href="#listar-pessoas">Listar Pessoas</a></li>
      </ul>
    </nav>
  );
};

export default Navbar;
