// import { Link, NavLink } from "react-router-dom";
import { NavLink } from "react-router-dom";

function Navbar() {
  return (
    <nav className="navbar navbar-expand bg-primary navbar-dark">
      <div className="container">
        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
          <li className="nav-item">
            <NavLink className="nav-link" to="/">Home</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link" to="/pessoas">Pessoas</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link" to="/categorias">Categorias</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link" to="/transacoes">Transações</NavLink>
          </li>
          <li className="nav-item dropdown">
            <a
              className="nav-link dropdown-toggle"
              href="#"
              id="relatoriosDropdown"
              role="button"
              data-bs-toggle="dropdown"
              aria-expanded="false"
            >
              Relatórios
            </a>
            <ul className="dropdown-menu" aria-labelledby="relatoriosDropdown">
              <li>
                <NavLink className="dropdown-item" to="/relatorios/pessoas">
                  Por Pessoas
                </NavLink>
              </li>
              <li>
                <NavLink className="dropdown-item" to="/relatorios/categorias">
                  Por Categorias
                </NavLink>
              </li>
            </ul>
          </li>
        </ul>
      </div>
    </nav>
  );
}

export default Navbar;