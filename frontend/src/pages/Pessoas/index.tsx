import { useEffect, useState } from "react"
import api from "../../services/api"
import PageLayout from "../../components/PageLayout"
import PageHeader from "../../components/PageHeader"
import TableList from "../../components/TableList"
import ConfirmDeleteModal from "../../components/ConfirmDeleteModal"
import PessoaModalForm from "./PessoaModalForm"
import type { Pessoa } from "../../interfaces/Pessoa"
import type { ApiResponse } from "../../interfaces/ApiResponse"
import { showError, showSuccess } from "../../services/toast"

function Pessoas() {
  const [pessoas, setPessoas] = useState<Pessoa[]>([])
  const [pessoa, setPessoa] = useState<Pessoa | null>(null)
  const [loading, setLoading] = useState(false)
  const [total, setTotal] = useState(0)
  const [showModal, setShowModal] = useState(false)
  const [showDelete, setShowDelete] = useState(false)

  const columns: { header: string; key: keyof Pessoa }[] = [
    { header: "Identificador", key: "id" },
    { header: "Nome", key: "nome" },
    { header: "Idade", key: "idade" }
  ]

  async function fetchPessoas() {
    setLoading(true)

    const response = await api.get<ApiResponse<Pessoa[]>>("/pessoa")

    if (response.data.isSuccess) {
      setPessoas(response.data.data)
      setTotal(response.data.data.length)
    } else {
      showError(response.data.messages.join("\n"))
    }

    setLoading(false)
  }

  useEffect(() => {
    // eslint-disable-next-line react-hooks/set-state-in-effect
    fetchPessoas()
  }, [])

  function handleCreate() {
    setPessoa(null)
    setShowModal(true)
  }

  function handleEdit(p: Pessoa) {
    setPessoa(p)
    setShowModal(true)
  }

  function handleDelete(p: Pessoa) {
    setPessoa(p)
    setShowDelete(true)
  }

  async function confirmDelete() {
    if (!pessoa) return

    const response = await api.delete<ApiResponse<unknown>>(`/pessoa/${pessoa.id}`)

    if (response.data.isSuccess) {
      showSuccess("Pessoa excluída com sucesso.")
      setShowDelete(false)
      setPessoa(null)
      fetchPessoas()
    } else {
      showError(response.data.messages.join("\n"))
    }
  }

  function handleCloseModal() {
    setShowModal(false)
    setPessoa(null)
  }

  return (
    <PageLayout>

      <PageHeader
        title="Pessoas"
        onAdd={handleCreate}
        addDisabled={loading}
      />

      <TableList
        data={pessoas}
        columns={columns}
        loading={loading}
        total={total}
        onEdit={handleEdit}
        onDelete={handleDelete}
      />

      <PessoaModalForm
        show={showModal}
        pessoa={pessoa}
        onClose={handleCloseModal}
        onSaved={fetchPessoas}
      />

      <ConfirmDeleteModal
        show={showDelete}
        message={`Deseja realmente excluir ${pessoa?.nome}?`}
        onConfirm={confirmDelete}
        onCancel={() => setShowDelete(false)}
      />

    </PageLayout>
  )
}

export default Pessoas