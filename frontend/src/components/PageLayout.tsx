function PageLayout({ children }: { children: React.ReactNode }) {
  return (
    <div className="container mt-4">
      {children}
    </div>
  )
}

export default PageLayout