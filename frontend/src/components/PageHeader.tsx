interface PageHeaderProps {
  title: string;
  onAdd?: () => void;
  addDisabled?: boolean
}

function PageHeader({ title, onAdd, addDisabled }: PageHeaderProps) {
  return (
    <div className="d-flex justify-content-between align-items-center mb-3">
      <h1 className="m-0">{title}</h1>
      {onAdd && (
        <button className="btn btn-primary" onClick={onAdd} disabled={addDisabled}>
          Adicionar
        </button>
      )}
    </div>
  );
}

export default PageHeader