import { useEffect, useState } from "react"
import api from "../../services/api"
import PageLayout from "../../components/PageLayout"
import PageHeader from "../../components/PageHeader"
import TableList from "../../components/TableList"
import ConfirmDeleteModal from "../../components/ConfirmDeleteModal"
import CategoriaModalForm from "./CategoriaModalForm"
import type { Categoria } from "../../interfaces/Categoria"
import type { ApiResponse } from "../../interfaces/ApiResponse"
import { showError, showSuccess } from "../../services/toast"

function Categorias() {
  const [categorias, setCategorias] = useState<Categoria[]>([])
  const [categoria, setCategoria] = useState<Categoria | null>(null)
  const [loading, setLoading] = useState(false)
  const [total, setTotal] = useState(0)
  const [showModal, setShowModal] = useState(false)
  const [showDelete, setShowDelete] = useState(false)

  const columns: { header: string; key: keyof Categoria }[] = [
    { header: "Identificador", key: "id" },
    { header: "Descrição", key: "descricao" },
    { header: "Finalidade", key: "finalidadeDescricao" }
  ]

  async function fetchCategorias() {
    setLoading(true)

    const response = await api.get<ApiResponse<Categoria[]>>("/categoria")

    if (response.data.isSuccess) {
      setCategorias(response.data.data)
      setTotal(response.data.data.length)
    } else {
      showError(response.data.messages.join("\n"))
    }

    setLoading(false)
  }

  useEffect(() => {
    // eslint-disable-next-line react-hooks/set-state-in-effect
    fetchCategorias()
  }, [])

  function handleCreate() {
    setShowModal(true)
  }

  function handleDelete(cat: Categoria) {
    setCategoria(cat)
    setShowDelete(true)
  }

  async function confirmDelete() {
    if (!categoria) return

    const response = await api.delete<ApiResponse<unknown>>(`/categoria/${categoria.id}`)

    if (response.data.isSuccess) {
      showSuccess("Categoria excluída com sucesso.")
      setShowDelete(false)
      setCategoria(null)
      fetchCategorias()
    } else {
      showError(response.data.messages.join("\n"))
    }
  }

  function handleCloseModal() {
    console.log("Fechar modal")
    setShowModal(false)
  }

  return (
    <PageLayout>

      <PageHeader
        title="Categorias"
        onAdd={handleCreate}
        addDisabled={loading}
      />

      <TableList
        data={categorias}
        columns={columns}
        loading={loading}
        total={total}
        onDelete={handleDelete}
      />

      <CategoriaModalForm
        show={showModal}
        onClose={handleCloseModal}
        onSaved={fetchCategorias}
      />

      <ConfirmDeleteModal
        show={showDelete}
        message={`Deseja realmente excluir a categoria "${categoria?.descricao}"?`}
        onConfirm={confirmDelete}
        onCancel={() => setShowDelete(false)}
      />

    </PageLayout>
  )
}

export default Categorias