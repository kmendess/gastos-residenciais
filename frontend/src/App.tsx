import { Routes, Route } from "react-router-dom"
import { ToastContainer } from "react-toastify"
import "react-toastify/dist/ReactToastify.css"
import Navbar from "./components/Navbar"
import Home from "./pages/Home"
import Pessoas from "./pages/Pessoas"
import Categorias from "./pages/Categorias"
import Transacoes from "./pages/Transacoes"

function App() {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/pessoas" element={<Pessoas />} />
        <Route path="/categorias" element={<Categorias />} />
        <Route path="/transacoes" element={<Transacoes />} />
      </Routes>
      <ToastContainer position="top-right" autoClose={5000} />
    </>
  )
}

export default App